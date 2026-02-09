/*
The template design pattern. Let's you implement an abstract class and lets you change the details.
Could do something similar for LLMs.
*/

public abstract class RagSystem
{
    public abstract void ConnectToRagSystem();
    public abstract string AskQuestion(string question);
    public abstract string ParseAnswer(string answer);

    /// <summary>
    /// Template method. All rag system must implement the individual parts.
    /// </summary>
    /// <param name="question"></param>
    /// <returns></returns>
    public string AskQuestionToRagSystem(string question)
    {
        ConnectToRagSystem();
        string answer = AskQuestion(question);
        string parsedAnswer = ParseAnswer(answer);
        return parsedAnswer;
    }
}
