// This file includes a widget called HeaderText. The purpose of the widget is
// to create header text inside the onboarding screen that is located below the four
// images.

import 'package:dark_knights/core/utils/colors.dart';
import 'package:flutter/material.dart';

class HeaderText extends StatelessWidget {
  final String text;
  const HeaderText({super.key, required this.text});

  @override
  Widget build(BuildContext context) {
    return Text(
      text,
      style: const TextStyle(
          fontSize: 27,
          fontFamily: 'urbanist',
          fontWeight: FontWeight.w200,
          fontStyle: FontStyle.italic,
          color: primaryTextColor),
    );
  }
}
