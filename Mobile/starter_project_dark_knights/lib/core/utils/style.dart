import 'package:flutter/material.dart';
import 'colors.dart';

TextStyle style(double screenHeight, double ls) {
  return TextStyle(
    letterSpacing: ls,
    height: screenHeight * 0.0018,
    fontSize: screenHeight * 0.025,
  );
}

TextStyle textStyle(double screenHeight, double ls) {
  return TextStyle(
    fontWeight: FontWeight.w100,
    letterSpacing: ls,
    // height: 50,
    fontSize: screenHeight * 0.02,
    fontStyle: FontStyle.italic,
    fontFamily: "Urbanist2",
    color: secondaryTextColor,
  );
}
