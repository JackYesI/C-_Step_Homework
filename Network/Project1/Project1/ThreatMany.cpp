////#include <thread>
////#include <iostream>
////#include <mutex>
////
////long s = 0;
////long i = 0;
////
////std::mutex m;
////
////void Show(const long* arr, int size)
////{
////    for (unsigned int i = 0; i < size; i++)
////    {
////        std::cout << arr[i] << " ";
////    } std::cout << std::endl;
////}
////
////bool isPrime(const long* arr)
////{
////    if (*arr == 1) return false;
////    for (unsigned int i = 2; i <= *arr / 2; i++)
////    {
////        if (*arr % i == 0) return false;
////    }
////    return true;
////}
////
////int next() {
////    m.lock();
////    int j = i++;
////    m.unlock();
////    return j;
////}
////
////void Run(const long* arr, int size)
////{
////    int j;
////    while ((j = next()) < size)
////    {
////        if (isPrime(&arr[j]))
////        {
////            m.lock();
////            s += arr[j];
////            m.unlock();
////        }
////    }
////}
////
////int main()
////{
////    int n;
////    std::cin >> n;
////    long* arra = new long[n];
////
////    for (unsigned int i = 0; i < n; i++)
////    {
////        std::cin >> arra[i];
////    }
////
////    /*Show(arra, n);
////
////    Run(arra, n);*/
////
////    std::thread t(Run, arra, n);
////    std::thread t_2(Run, arra, n);
////    t.join();
////    t_2.join();
////    std::cout << "SUM = " << s << std::endl;
////    return 0;
////}
//
//// вище lock unlock and mutex
///// атомарні змінні
//
////#include <thread>
////#include <iostream>
//////#include <atomic>
////
////std::atomic <long> s(0);
////std::atomic<long> i(0);
////
////
////
////void Show(const long* arr, int size)
////{
////    for (unsigned int i = 0; i < size; i++)
////    {
////        std::cout << arr[i] << " ";
////    } std::cout << std::endl;
////}
////
////bool isPrime(const long* arr)
////{
////    if (*arr == 1) return false;
////    for (unsigned int i = 2; i <= *arr / 2; i++)
////    {
////        if (*arr % i == 0) return false;
////    }
////    return true;
////}
////
////int next() {
////    int j = i++;
////    return j;
////}
////
////void Run(const long* arr, int size)
////{
////    int j;
////    while ((j = next()) < size)
////    {
////        if (isPrime(&arr[j]))
////        {
////            s += arr[j];
////        }
////    }
////}
////
////int main()
////{
////    int n;
////    std::cin >> n;
////    long* arra = new long[n];
////
////    for (unsigned int i = 0; i < n; i++)
////    {
////        std::cin >> arra[i];
////    }
////
////    /*Show(arra, n);
////
////    Run(arra, n);*/
////
////    std::thread t(Run, arra, n);
////    std::thread t_2(Run, arra, n);
////    t.join();
////    t_2.join();
////    std::cout << "SUM = " << s << std::endl;
////    return 0;
////}
//
///// Async 
//
//#include <iostream>
//#include <future>
//#include <thread>
//#include <chrono>
//
//using namespace std;
//
//int AsynkFunc(int x)
//{
//	std::this_thread::sleep_for(std::chrono::seconds(1));  // імітація операції
//	return x * x;
//}
//
//int main()
//{
//	// запуск асинхроної функції
//	std::future<int> result = std::async(std::launch::async, AsynkFunc, 5);
//	std::cout << "Cheak how async function work!!!" << std::endl;
//
//	while (result.wait_for(std::chrono::seconds(0)) != std::future_status::ready) {
//		std::cout << "function don't ready to return the result !!!" << std::endl;
//	}
//
//	int value = result.get();
//
//	std::cout << "return result is " << value << std::endl;
//
//
//	// і приклад як перевірити чи асинхронна завершила свою роботу
//	std::future<int> result_2 = std::async(std::launch::async, AsynkFunc, 3);
//
//	return 0;
//}