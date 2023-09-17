using System;
using System.Net;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using nf.classLibrary;

namespace en_front_back.Controllers;

[ApiController]
[Route("[controller]")]
public class Nf_DataController : ControllerBase
{

    public Nf_DataController()
    {
    }
    [HttpGet(Name = "Index")]
    [Route("/")]
    public ContentResult Index()
    {
        return new ContentResult
        {
            ContentType = "text/html",
            StatusCode = (int)HttpStatusCode.OK,
            Content = "<html><body>Front Back Ensamble 1.0.1 </body></html>"
        };

    }
    [HttpPost(Name = "ExecuteForCRUD")]
    [Route("/api/Nf_Data/ExecuteForCRUD")]
    public IActionResult ExecuteForCRUD()
    {
        RespondResult rr = new RespondResult();
        var formData = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

        if (formData["ClassName"] is not null)
        {
            string className = formData["ClassName"].ToString();
            if (className.ToUpper().IndexOf("RM_") == 0)
            {
                formData.Add("db", "Prometeo_Redes");
                formData.Add("ShowDataModel", "false");
                formData.Add("ShowDataTable", "false");
            }
        }
        string postString = "";
        foreach (string key in formData.Keys)
        {
            postString += key + "=" + formData[key] + "&";
        }




        string serverName = "http://backo.globaltoons.tv:3002";
        string endPoint = serverName + "/api/Nf_Data/ExecuteForCRUD";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";



        byte[] bytes = Encoding.UTF8.GetBytes(postString);
        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(bytes, 0, bytes.Length);
        }

        HttpWebResponse httpResponse = (HttpWebResponse)(request.GetResponse());
        string json;
        using (Stream responseStream = httpResponse.GetResponseStream())
        {
            json = new StreamReader(responseStream).ReadToEnd();
        }

        //return JsonConvert.DeserializeObject<RespondResult>(json);
        return Content(json, "application/json");

    }
    [HttpPost(Name = "GetCombo")]
    [Route("/api/Nf_Data/GetCombo")]
    public RespondResult GetCombo()
    {
        RespondResult rr = new RespondResult();

        return rr;

    }
}

