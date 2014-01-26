using ScriptCs.Contracts;

namespace ScriptCs.Request
{
    public class ScriptPack : IScriptPack
    {
        IScriptPackContext IScriptPack.GetContext()
        {
            //Return the ScriptPackContext to be used in your scripts
            return new Request();
        }

        void IScriptPack.Initialize(IScriptPackSession session)
        {
            //Here you can perform initialization like pass using statements 
            //and references by using the session object's two methods:

            //AddReference
            //Use this method to add library references that need to be 
            //available in your script. After the script pack is loaded, 
            //the specified references will be available for use 
            //without any code inside the script.
            session.AddReference("System.Net.Http");

            //ImportNamespace
            //This method can import namespaces for use in your scripts to help 
            //keep user's scripts clean and simple.
            session.ImportNamespace("System.Net.Http");
            session.ImportNamespace("Newtonsoft.Json");
        }

        void IScriptPack.Terminate()
        {
            //Cleanup any resources here
        }
    }
}