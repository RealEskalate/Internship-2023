// This file includes a widget called Dot. The purpose of the widget is
// to create the small circular containers in the bottom left side of the
// bottom navigation of the onboarding screen

import 'package:dark_knights/core/constants/colors.dart';
import 'package:flutter/material.dart';

class Dot extends StatelessWidget {
  final double width;
  final bool isBlue;
  const Dot({super.key, required this.width, required this.isBlue});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.all(5),
      width: width,
      height: 10,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(50),
        color: isBlue ? dotBlueColor : dotGreyColor,
      ),
    );
  }
}
