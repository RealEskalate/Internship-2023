import 'package:flutter/material.dart';

const designHeight = 934;
const designWidth = 428;

double convertPixelToScreenHeight(BuildContext context, double pixels) {
  final double screenHeight = MediaQuery.of(context).size.height;
  return screenHeight * (pixels / designHeight);
}

double convertPixelToScreenWidth(BuildContext context, double pixels) {
  final double screenWidth = MediaQuery.of(context).size.width;
  return screenWidth * (pixels / designWidth);
}
