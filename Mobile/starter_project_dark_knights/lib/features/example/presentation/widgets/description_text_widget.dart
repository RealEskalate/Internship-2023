import 'package:dark_knights/core/constants/colors.dart';
import 'package:flutter/material.dart';

class DescriptionText extends StatelessWidget {
  final String text;
  const DescriptionText({super.key, required this.text});

  @override
  Widget build(BuildContext context) {
    return Text(
      text,
      style: const TextStyle(
          fontSize: 18,
          fontFamily: "Urbanist",
          fontWeight: FontWeight.w900,
          color: descriptionTextColor),
    );
  }
}
