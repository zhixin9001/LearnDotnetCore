using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace _3._1_Prepare {
  class Program {
    static void Main(string[] args) {
      #region 线程细节
      //int i = 5;
      //Thread thread = new Thread(() => {
      //  Console.WriteLine(i);
      //});
      //thread.Start();
      //i = 6;
      #endregion

      #region 参数化
      //int i = 5;
      //Thread thread = new Thread((ii) => {
      //  Console.WriteLine(ii);
      //});
      //thread.Start(i);
      //i = 6;
      #endregion

      //Interrupt();

      //Join();

      //DrawMoneyMain();

      WaitHandle();

      //ThreadPool1();

      Console.ReadKey();
    }

    static void Interrupt() {
      Thread t1 = new Thread(() => {
        Console.WriteLine("t1 will sleep");
        try {
          Thread.Sleep(5000);
        }
        catch (ThreadInterruptedException) {
          Console.WriteLine("interrupted");
        }
        Console.WriteLine("t1 wake up");
      });

      t1.Start();
      Thread.Sleep(1000);
      t1.Interrupt();
    }

    static void Join() {
      Thread t1 = new Thread(() => {
        for (int i = 0; i < 100; i++) {
          Console.WriteLine("t1=" + i);
        }
      });

      Thread t2 = new Thread(() => {
        t1.Join();
        for (int i = 0; i < 100; i++) {
          Console.WriteLine("t2=" + i);
        }
      });
      t1.Start();
      t2.Start();
    }

    static int money = 10000;
    //[MethodImpl(MethodImplOptions.Synchronized)]
    static void DrawMoney(string name) {
      Console.WriteLine(name + " checked the account:" + money);
      Monitor.Enter("locker");


      //lock ("locker") {
      int yue = money - 1;
      Console.WriteLine(name + " draw money");
      money = yue;
      //}
      Monitor.Exit("locker");
      Console.WriteLine(name + "drawed, left: " + money);
    }
    static void DrawMoneyMain() {
      Thread t1 = new Thread(() => {
        for (int i = 0; i < 1000; i++) {
          DrawMoney("t1");
        }
      });
      Thread t2 = new Thread(() => {
        for (int i = 0; i < 1000; i++) {
          DrawMoney("t2");
        }
      });

      t1.Start();
      t2.Start();

      Console.WriteLine("LEFT: " + money);
    }

    static void WaitHandle() {
      #region 1
      //ManualResetEvent mre = new ManualResetEvent(false);
      //Thread t1 = new Thread(()=> {
      //  Console.WriteLine("waitting open");
      //  mre.WaitOne();
      //  Console.WriteLine("Open");
      //});

      //t1.Start();
      //Console.WriteLine("press!...");
      //Console.ReadKey();
      //mre.Set();
      //Console.ReadKey();
      #endregion

      #region 2
      //ManualResetEvent mre = new ManualResetEvent(false);
      //Thread t1 = new Thread(() => {
      //  Console.WriteLine("waitting open");
      //if(mre.WaitOne(2000)) {
      //    Console.WriteLine("Open");
      //  }
      //  else {
      //    Console.WriteLine("after 2000");
      //  }

      //});

      //t1.Start();
      //Console.WriteLine("press!...");
      //Console.ReadKey();
      //mre.Set(); 
      //Console.ReadKey();

      #endregion

      #region 3
      AutoResetEvent are = new AutoResetEvent(false);
      Thread t1 = new Thread(() => {
        while (true) {
          Console.WriteLine("waitting open");
          are.WaitOne();
          Console.WriteLine("Open");
        }
      });
      Thread t2 = new Thread(() => {
        while (true) {
          Console.WriteLine("waitting1 open");
          are.WaitOne();
          Console.WriteLine("Open1");
        }
      });
      t1.IsBackground = true;
      t1.Start();
      t2.IsBackground = true;
      t2.Start();
      Console.WriteLine("press!...");
      Console.ReadKey();
      are.Set();
      Console.ReadKey();
      are.Set();
      Console.ReadKey();
      are.Set();
      Console.ReadKey();

      #endregion

      #region 4
      //ManualResetEvent are = new ManualResetEvent(false);
      //Thread t1 = new Thread(() => {
      //  while (true) {
      //    Console.WriteLine("waitting open");
      //    are.WaitOne();
      //    Console.WriteLine("Open");
      //  }
      //});
      //t1.IsBackground = true;
      //t1.Start();
      //Console.WriteLine("press!...");
      //Console.ReadKey();
      //are.Set();
      //Console.ReadKey();
      //are.Reset();
      //Console.ReadKey();
      //are.Set();
      //Console.ReadKey();

      #endregion
    }

    static void ThreadPool1() {
      Console.WriteLine("main begin");
      ThreadPool.QueueUserWorkItem((state)=> {
        Console.WriteLine("thread begin");
        
      });
    }
  }

  class Singleton {
    private Singleton() { }
    private static object locker = new object();
    private static Singleton instance = null;

    public static Singleton GetSingleton() {
      if (instance == null) {
        lock (locker) {
          instance = new Singleton();
        }
      }
      return instance;
    }
  }
}
