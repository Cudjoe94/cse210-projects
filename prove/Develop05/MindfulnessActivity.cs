namespace MindfulnessApp
{
    public abstract class MindfulnessActivity
    {
        // Class implementation
        private string _activityName;
        private string _activityDescription;
        protected int _durationInSeconds;

        public string ActivityName
        {
            get { return _activityName; }
            protected set { _activityName = value; }
        }

        public string ActivityDescription
        {
            get { return _activityDescription; }
            protected set { _activityDescription = value; }
        }

        public void StartActivity()
        {
            ShowStartingMessage();
            _durationInSeconds = GetDuration();
            PrepareUser();
            ExecuteActivity();
            EndActivity();
            LogSession();
        }

        protected abstract void ShowStartingMessage();
        protected abstract void ExecuteActivity();
        protected abstract void ShowEndingMessage();

        protected int GetDuration()
        {
            Console.Write("Enter the duration of the activity in seconds: ");
            return int.Parse(Console.ReadLine());
        }

        protected void PrepareUser()
        {
            Console.WriteLine("Get ready... Preparing to start...");
            Thread.Sleep(3000);
        }

        protected void EndActivity()
        {
            ShowEndingMessage();
            Console.WriteLine("Great job! You've completed your activity.");
            Thread.Sleep(3000);
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        protected void ShowSpinnerAnimation()
        {
            string[] spinner = { "/", "-", "\\", "|" };
            int i = 0;

            for (int j = 0; j < 10; j++)
            {
                Console.Write(spinner[i]);
                Thread.Sleep(500);
                Console.Write("\b \b");
                i = (i + 1) % 4;
            }
        }

        protected void LogSession()
        {
            string logFilePath = "SessionLog.txt";
            File.AppendAllText(logFilePath, $"{DateTime.Now}: Completed {ActivityName} activity for {_durationInSeconds} seconds.\n");
        }
    }
}
