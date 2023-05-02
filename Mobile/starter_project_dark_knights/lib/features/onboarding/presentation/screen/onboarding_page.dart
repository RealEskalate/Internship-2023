import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/features/onboarding/presentation/widgets/onboarding/description_text.dart';
import 'package:dark_knights/features/onboarding/presentation/widgets/onboarding/stepper_dot.dart';
import 'package:dark_knights/features/onboarding/presentation/widgets/onboarding/header_text.dart';
import 'package:dark_knights/features/onboarding/presentation/widgets/onboarding/onboarding_row_images.dart';
import 'package:dark_knights/main.dart';
import 'package:flutter/material.dart';

class OnboardingScreen extends StatefulWidget {
  const OnboardingScreen({super.key});

  @override
  State<OnboardingScreen> createState() => _OnboardingScreenState();
}

class _OnboardingScreenState extends State<OnboardingScreen> {
  List<List<double>> widths = [
    [25.0, 10.0, 10.0],
    [10.0, 25.0, 10.0],
    [10.0, 10.0, 25.0],
  ];
  List<List<bool>> colors = [
    [true, false, false],
    [false, true, false],
    [false, false, true]
  ];
  int index = 0;
  final String headerText = 'Read the article you want instantly.';
  final String descriptionText =
      'You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.';
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: scaffoldBackground,
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            SizedBox(height: MediaQuery.of(context).size.height * 0.07),
            Padding(
              padding: const EdgeInsets.all(35.0),
              child: Column(
                children: const [
                  UpperRowImages(
                      image1: 'onboarding_1',
                      image2: 'onboarding_2',
                      flex1: 1,
                      flex2: 2),
                  UpperRowImages(
                      image1: 'onboarding_3',
                      image2: 'onboarding_4',
                      flex1: 2,
                      flex2: 1),
                ],
              ),
            ),
            Expanded(
              child: Container(
                width: double.infinity,
                padding: const EdgeInsets.all(35),
                decoration: const BoxDecoration(
                    color: whiteColor,
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(40),
                      topRight: Radius.circular(40),
                    )),
                child: Column(
                  children: [
                    HeaderText(
                      text: headerText,
                    ),
                    SizedBox(height: MediaQuery.of(context).size.height * 0.03),
                    DescriptionText(text: descriptionText),
                    SizedBox(height: MediaQuery.of(context).size.height * 0.03),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceAround,
                          children: [
                            StepperDot(
                                width: widths[index][0],
                                isBlue: colors[index][0]),
                            StepperDot(
                                width: widths[index][1],
                                isBlue: colors[index][1]),
                            StepperDot(
                                width: widths[index][2],
                                isBlue: colors[index][2]),
                          ],
                        ),
                        Container(
                          decoration: BoxDecoration(
                              color: primaryColor,
                              borderRadius: BorderRadius.circular(10)),
                          width: MediaQuery.of(context).size.width * 0.25,
                          height: MediaQuery.of(context).size.width * 0.16,
                          child: InkWell(
                            onTap: () => {
                              if (index >= 2)
                                {
                                  Navigator.push(
                                    context,
                                    MaterialPageRoute(
                                      builder: (context) => const MyHomePage(
                                        title: "",
                                      ),
                                    ),
                                  )
                                }
                              else
                                {
                                  setState(() {
                                    index++;
                                  })
                                }
                            },
                            child: const Icon(
                              Icons.arrow_forward,
                              color: Colors.white,
                            ),
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
