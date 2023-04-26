import 'package:flutter/material.dart';

import '../../../core/utils/colors.dart';
import '../../../core/utils/images.dart';
import '../widgets/onboarding_box.dart';
import '../widgets/onboarding_button.dart';
import '../widgets/slide_dots.dart';

class Onboarding extends StatefulWidget {
  const Onboarding({super.key});

  @override
  State<Onboarding> createState() => _OnboardingState();
}

class _OnboardingState extends State<Onboarding> {
  int index = 0;
  static const pageTitle = "Read the article you want instantly";
  static const pageDescription =
      "You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: scaffoldBackground,
        body: Column(
          children: [
            SizedBox(
              height: MediaQuery.of(context).size.height * 0.05,
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
                          OnboardingBox(
                            imageUrl: onBoardingPhoto1,
                            isLarge: false,
                          ),
                          OnboardingBox(
                              imageUrl: onBoardingPhoto2, isLarge: true,)
                        ],
                      ),
                      Row(
                        children: [
                          OnboardingBox(imageUrl: onBoardingPhoto3, isLarge: true),
                          OnboardingBox(imageUrl: onBoardingPhoto4, isLarge: false)
                        ],
                      ),
                      SizedBox(
                        height: MediaQuery.of(context).size.height * 0.015,
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
                    left: MediaQuery.of(context).size.width * 0.13,
                    right: MediaQuery.of(context).size.width * 0.15),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    SizedBox(
                      height: MediaQuery.of(context).size.height * 0.03,
                    ),
                    const Text(pageTitle,
                        style: TextStyle(
                          fontSize: 24,
                          fontStyle: FontStyle.italic,
                          fontFamily: "urbanist",
                          fontWeight: FontWeight.w100,
                        )),
                    const Text(pageDescription,
                        style: TextStyle(
                            color: secondaryTextColor,
                            fontFamily: "popins",
                            fontSize: 14,
                            fontWeight: FontWeight.w900)),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        SlideDotes(
                          index: index,
                        ),
                        OnboardingButton(onTap: () {
                          setState(() {
                            index = (index + 1) % 3;
                          });
                        })
                      ],
                    ),
                    SizedBox(
                      height: MediaQuery.of(context).size.height * 0.03,
                    ),
                  ],
                ),
              ),
            )),
          ],
        ));
  }
}
