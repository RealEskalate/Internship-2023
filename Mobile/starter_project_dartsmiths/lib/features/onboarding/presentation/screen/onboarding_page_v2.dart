import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';
import '../../../../core/utils/images.dart';
import '../widgets/onboarding_stepper_box.dart';
import '../widgets/onboarding_stepper_button.dart';
import '../widgets/stepper_dots.dart';

class OnboardingPage extends StatefulWidget {
  const OnboardingPage({super.key});

  @override
  State<OnboardingPage> createState() => _OnboardingPageState();
}

class _OnboardingPageState extends State<OnboardingPage> {
  int index = 0;
  static const pageTitle = "Read the article you want instantly";
  static const pageDescription =
      "You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.";

  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final screenWidth = MediaQuery.of(context).size.width;
    return Scaffold(
        backgroundColor: scaffoldBackground,
        body: Column(
          children: [
            SizedBox(
              height: screenHeight * 0.05,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Padding(
                  padding: const EdgeInsets.all(6.0),
                  child: Column(
                    children: [
                      Row(
                        children: [
                          OnboardingStepperBox(
                            imageUrl: onBoardingPhoto1,
                            isLarge: false,
                          ),
                          OnboardingStepperBox(
                            imageUrl: onBoardingPhoto2,
                            isLarge: true,
                          )
                        ],
                      ),
                      Row(
                        children: [
                          OnboardingStepperBox(
                              imageUrl: onBoardingPhoto3, isLarge: true),
                          OnboardingStepperBox(
                              imageUrl: onBoardingPhoto4, isLarge: false)
                        ],
                      ),
                      SizedBox(
                        height: screenHeight * 0.015,
                      ),
                    ],
                  ),
                ),
              ],
            ),
            Expanded(
                child: Container(
              decoration: const BoxDecoration(
                  borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(24),
                      topRight: Radius.circular(24)),
                  color: Colors.white),
              width: double.infinity,
              child: Padding(
                padding: EdgeInsets.only(
                    left: screenWidth * 0.13, right: screenWidth * 0.15),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    SizedBox(
                      height: screenHeight * 0.03,
                    ),
                    Text(pageTitle,
                        style: TextStyle(
                          fontSize: screenWidth * 0.08 * (8 / 10),
                          fontStyle: FontStyle.italic,
                          fontFamily: "urbanist",
                          fontWeight: FontWeight.w100,
                        )),
                    Text(pageDescription,
                        style: TextStyle(
                            color: secondaryTextColor,
                            fontFamily: "popins",
                            fontSize: screenWidth * 0.045 * (8 / 10),
                            fontWeight: FontWeight.w900)),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        StepperDots(
                          index: index,
                        ),
                        OnboardingStepperButton(onTap: () {
                          setState(() {
                            index = (index + 1) % 3;
                          });
                        })
                      ],
                    ),
                    SizedBox(
                      height: screenHeight * 0.03,
                    ),
                  ],
                ),
              ),
            )),
          ],
        ));
  }
}
