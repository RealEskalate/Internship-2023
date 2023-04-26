import 'package:flutter/material.dart';
import 'package:matador/features/onboarding/presentation/widgets/animated_entry.dart';
import 'package:matador/features/onboarding/presentation/widgets/introduction.dart';

class OnBoardingScreen extends StatefulWidget {
  const OnBoardingScreen({super.key});

  @override
  State<OnBoardingScreen> createState() => _OnBoardingState();
}

class _OnBoardingState extends State<OnBoardingScreen> {
  double displaced = -350;
  String topic = "Read the article you want instantly";
  String content =
      "You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.";
  @override
  void initState() {
    super.initState();
    Future.delayed(const Duration(milliseconds: 500), () {
      setState(() {
        displaced = 0;
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    var longContainerWidth = size.width * (1 / 3) * 0.9;
    var longContainerHeight = size.height * (3 / 5) * 0.4;
    var wideContainerWidth = size.width * (2 / 3) * 0.9;
    var wideContainerHeight = size.height * (3 / 5) * 0.4;
    return Column(children: [
      Container(
        margin: EdgeInsets.only(top: size.height * 0.01),
        padding: const EdgeInsets.all(10),
        width: size.width,
        height: size.height * (2.8 / 5),
        child: Stack(
          children: [
            AnimatedEntry(
              width: longContainerWidth,
              height: longContainerHeight,
              image: const AssetImage("assets/images/background1.png"),
              top: displaced,
              left: 0,
            ),
            AnimatedEntry(
              width: wideContainerWidth,
              height: wideContainerHeight,
              image: const AssetImage("assets/images/background2.png"),
              right: displaced,
              top: 0,
            ),
            AnimatedEntry(
              width: longContainerWidth,
              height: longContainerHeight,
              image: const AssetImage("assets/images/background3.png"),
              bottom: displaced,
              right: 0,
            ),
            AnimatedEntry(
              width: wideContainerWidth,
              height: wideContainerHeight,
              image: const AssetImage("assets/images/background4.png"),
              left: displaced,
              bottom: 0,
            ),
          ],
        ),
      ),
      Expanded(child: Introduction(topic, content, 1, 3))
    ]);
  }
}
