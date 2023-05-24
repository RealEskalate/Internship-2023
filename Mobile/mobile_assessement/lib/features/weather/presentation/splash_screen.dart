import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:mobile_assessement/features/weather/presentation/search_screen.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({super.key});

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    double windowHeight = size.height;
    double windowWidth = size.width;

    return Scaffold(
      backgroundColor: Color(0XFF3C2DB9),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Image(
              image: AssetImage("assets/images/rainy_lightning_windy_sunny.png"),
              height: windowHeight * 0.5,
              width: windowWidth,
            ),
            SizedBox(
              height: 20,
            ),
            const Text(
              "Weather",
              style: TextStyle(fontSize: 30, color: Color(0xFFFFBA25)),
            ),
            SizedBox(
              height: 20,
            ),
            const Text(
              "Forecast App",
              style:
                  TextStyle(fontSize: 30, color: Color.fromARGB(255, 236, 232, 232)),
            ),
            SizedBox(
              height: 20,
            ),
            const Text(
              "It's the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has.",
              style: TextStyle(fontSize: 14, color: Color.fromARGB(255, 252, 252, 252)),
            ),
            SizedBox(
              height: 30,
            ),

            GestureDetector(
              child: Padding(
                padding: const EdgeInsets.only(left: 60, right: 50),
                child: Container(
                  width: 220,
                  height: 48,
                  decoration: BoxDecoration(
                      color: Color(0xFFFFBA25),
                      borderRadius: BorderRadius.circular(20)),
                  child: Center(
                      child: const Text(
                    "Get Started",
                    style: TextStyle(color: Color.fromARGB(255, 14, 12, 12)),
                  )),
                ),
              ),
              onTap: () => Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => SearchScreen(),
                ),
              )
            ),
          ],
        ),
      ),
    );
  }
}
