using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;
using Filters;

public class UserModel
{
    public int Id{get;set;}
    public string Name { get; set; }
    public string Email { get; set; }   
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}

[Route("api/[controller]s")]
[Produces("application/json")]
    [TypeFilter(typeof(AuthorizationFilter))]
public class UserController : Controller
{
    private static List<UserModel> users = new List<UserModel>();
    ///<summary>
    ///查詢使用者清單
    ///</summary>
    ///<param name="q">查詢使用者名稱</param>
    ///<returns>使用者清單</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ResultModel), 200)]
    [ProducesResponseType(typeof(string), 500)]
    [TypeFilter(typeof(ActionFilter))]
    public ResultModel Get(string q)
    {
        var result = new ResultModel();
        result.Data = users.Where( c => string.IsNullOrEmpty(q)
                                    || Regex.IsMatch(c.Name, q, RegexOptions.IgnoreCase));
        result.IsSuccess = true;
        return result;
    }
    [ResourceFilter]
    [HttpGet("{id}")]
    public ResultModel Get(int id)
    {
        var result = new ResultModel();
        result.Data =  users.SingleOrDefault(c => c.Id == id);
        return result;
    }
    [HttpPost]
    public ResultModel Post([FromBody]UserModel user)
    {
        var result = new ResultModel();
        user.Id = users.Count() == 0 ? 1 : users.Max(c => c.Id) +1;
        users.Add(user);
        result.Data = user.Id;
        result.IsSuccess = true;
        return result;
    }
    [HttpPut]
    public ResultModel put(int id, [FromBody]UserModel user)
    {
        var result = new ResultModel();
        int index;
        if((index= users.FindIndex(c => c.Id == id)) != -1){
            users[index] = user;
            result.IsSuccess = true;
        }
        return result;
    }
    [HttpDelete]
    public ResultModel Delete(int id){
        var result = new ResultModel();
        int index;
        if((index = users.FindIndex(c => c.Id == id)) != -1){
            users.RemoveAt(index);
            result.IsSuccess = true;
        }
        return result;
    }

}