import 'package:dark_knights/core/shared_widgets/onboarding_row_images.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

class OnboardingScreen extends StatefulWidget {
  const OnboardingScreen({super.key});

  @override
  State<OnboardingScreen> createState() => _OnboardingScreenState();
}

class _OnboardingScreenState extends State<OnboardingScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromRGBO(246, 248, 255, 1),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Padding(
              padding: const EdgeInsets.all(35.0),
              child: Column(
                children: const [
                  UpperRowImages(image1: '1', image2: '2', flex1: 1, flex2: 2),
                  UpperRowImages(image1: '3', image2: '4', flex1: 2, flex2: 1),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
