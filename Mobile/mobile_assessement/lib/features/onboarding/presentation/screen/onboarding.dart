import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

class Onboarding extends StatelessWidget {
  const Onboarding({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Expanded(
        child: Container(
          child: Column(children: [
            Center(child: Image.asset("assets/images/weather1.jpg")),
            Container(
              child: Text("Weather"),
            ),
            Container(
              child: Text("Forecast App."),
            ),
            Container(
              child: Text(
                  "It's the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has."),
            ),
            ElevatedButton(onPressed: () {}, child: Text("Get Started"))
          ]),
        ),
      ),
    );
  }
}
