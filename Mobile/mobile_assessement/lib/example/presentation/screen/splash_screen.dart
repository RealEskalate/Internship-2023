import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:mobile_assessement/core/utils/constants/global_variables.dart';

import '../widgets/get_started_button.dart';

class SplashScreen extends StatelessWidget {
  const SplashScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        width: double.infinity,
        height: double.infinity,
        color: primaryBackgoundColor,
        child: SingleChildScrollView(
          scrollDirection: Axis.vertical,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Center(
                child: Padding(
                  padding: const EdgeInsets.all(50),
                  child: SvgPicture.asset(
                    'assets/images/rainy_lightning.svg',
                    semanticsLabel: 'mostly_sunny',
                  ),
                ),
              ),
              Padding(
                padding: const EdgeInsets.only(right: 80.0, left: 30),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text(
                      'Weather',
                      style: TextStyle(
                        color: primaryButtonColor,
                        fontSize: 36.0,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    const Text(
                      'Forecast App',
                      style: TextStyle(fontSize: 36.0, color: whiteColor),
                    ),
                    const SizedBox(height: 20.0),
                    const Text(
                      'It\'s the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has.',
                      style: TextStyle(
                        color: whiteColor,
                        fontSize: 16.0,
                      ),
                    ),
                  ],
                ),
              ),
              const SizedBox(height: 40.0),
              Center(child: const GetStartedButton()),
              const SizedBox(height: 20.0),
            ],
          ),
        ),
      ),
    );
  }
}
