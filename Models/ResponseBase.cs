namespace TF_ClassRegistry.Models;

public class ResponseBase<T>
{
    public string? Code {  get; set; }
    public string? Message {  get; set; }
    public dynamic? Error {  get; set; }
    public T? Data {  get; set; }
}
