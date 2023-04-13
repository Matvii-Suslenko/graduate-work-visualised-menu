using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using System.Text;
using System.Net;

public class ServerLogic : MonoBehaviour
{
    [SerializeField] private Text _lastOrderIdText;
    [SerializeField] private GameObject _orderSample;
    [SerializeField] private Transform _orderParent;
    
    private const string URL = "http://localhost:8000/";

    private HttpListener _listener;
    private int _requestCount = 0;
    private int _lastOrderId = 0;

    private Queue<KeyValuePair<int, string>> _unprocessedOrders = new Queue<KeyValuePair<int, string>>();

    private void Start()
    {
        // Create a Http server and start listening for incoming connections
        _listener = new HttpListener();
        _listener.Prefixes.Add(URL);
        _listener.Start();
        Debug.Log($"Listening for connections on {URL}");
    
        // Handle requests
        var listenTask = HandleIncomingConnections();
        //listenTask.GetAwaiter().GetResult();
    }

    private void Update()
    {
        _lastOrderIdText.text = $"Last Order Id: {_lastOrderId}";

        while (_unprocessedOrders.Count > 0)
        {
            var unprocessedOrder = _unprocessedOrders.Dequeue(); var newOrder = Instantiate(_orderSample, _orderParent);
            newOrder.GetComponent<OrderBehaviour>().SetOrderInfo(unprocessedOrder.Key, unprocessedOrder.Value);
        }
    }

    private void OnDestroy()
    {
        // Close the listener
        _listener.Close();
    }

    private async Task HandleIncomingConnections()
    {
        // While a user hasn't visited the `shutdown` url, keep on handling requests
        while (true)
        {
            // Will wait here until we hear from a connection
            var ctx = await _listener.GetContextAsync();
    
            // Peel out the requests and response objects
            var request = ctx.Request;
            var resp = ctx.Response;
    
            // Print out some info about the request
            Debug.Log($"Request #: {++_requestCount} {request.Url}  [{request.HttpMethod}]");
    
            // If `shutdown` url requested w/ POST
            if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/order")
            {
                var body = request.InputStream;
                var encoding = request.ContentEncoding;
                var reader = new System.IO.StreamReader(body, encoding);
                var bodyString = await reader.ReadToEndAsync();
                
                Debug.Log($"Received order: {bodyString}");
                _lastOrderId += 1;
                
                _unprocessedOrders.Enqueue(new KeyValuePair<int, string>(_lastOrderId, bodyString));
                
                // Write the response info
                var data = Encoding.UTF8.GetBytes(_lastOrderId.ToString());
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;// Write out to the response stream (asynchronously), then close it
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
            }
            resp.Close();
        }
    }
}
