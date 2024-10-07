namespace Crypto.Base.Models;

public class ResponseModel<T>
{
    public T Result { get; set; }
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public bool IsSuccessful { get; set; }
}