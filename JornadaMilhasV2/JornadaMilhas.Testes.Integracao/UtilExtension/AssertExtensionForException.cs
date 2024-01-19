namespace JornadaMilhas.Testes.Integracao.UtilExtension;
public static class AssertExtensionForException
{
    public static void ExceptionMessage(this Exception exception,string message)
    {
        if(!exception.Message.Equals(message))
        {
            Assert.False(true);
        }
        else
        {
            Assert.True(true);
        }
    }
}
