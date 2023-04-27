import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/features/onboarding/presentation/widgets/onboarding/description_text.dart';
import 'package:dark_knights/features/onboarding/presentation/widgets/onboarding/dot.dart';
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
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: scaffoldBackground,
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const SizedBox(height: 50),
            Padding(
              padding: const EdgeInsets.all(35.0),
              child: Column(
                children: const [
                  UpperRowImages(image1: '1', image2: '2', flex1: 1, flex2: 2),
                  UpperRowImages(image1: '3', image2: '4', flex1: 2, flex2: 1),
                ],
              ),
            ),
            Expanded(
              child: Container(
                width: double.infinity,
                padding: const EdgeInsets.all(35),
                decoration: const BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(40),
                      topRight: Radius.circular(40),
                    )),
                child: Column(
                  children: [
                    const HeaderText(
                      text: 'Read the article you want instantly.',
                    ),
                    const SizedBox(height: 30),
                    const DescriptionText(
                        text:
                            'You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.'),
                    const SizedBox(height: 30),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceAround,
                          children: [
                            Dot(
                                width: widths[index][0],
                                isBlue: colors[index][0]),
                            Dot(
                                width: widths[index][1],
                                isBlue: colors[index][1]),
                            Dot(
                                width: widths[index][2],
                                isBlue: colors[index][2]),
                          ],
                        ),
                        Container(
                          decoration: BoxDecoration(
                              color: primaryColor,
                              borderRadius: BorderRadius.circular(10)),
                          width: 100,
                          height: 65,
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
