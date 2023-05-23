import 'package:flutter/material.dart';
import 'colors.dart';

// TEXT STYLES

const weatherTextStyle = TextStyle(
    fontFamily: 'Roboto',
    fontStyle: FontStyle.normal,
    fontWeight: FontWeight.w500,
    fontSize: 24,
    height:
        1.18, // This corresponds to line-height: 52px with a font-size of 44px
    color: secondaryColor);

const ForecastTextStyle = TextStyle(
  fontFamily: 'Roboto',
  fontStyle: FontStyle.normal,
  fontWeight: FontWeight.w500,
  fontSize: 16,
  height:
      1.17, // This corresponds to line-height: 42px with a font-size of 36px
  color: Colors.white, // This corresponds to color: #FFFFFF in CSS
);

const descriptionTextStyle = TextStyle(
  fontFamily: 'Roboto',
  fontStyle: FontStyle.normal,
  fontWeight: FontWeight.w400,
  fontSize: 12,
  height:
      1.67, // This corresponds to line-height: 20px with a font-size of 12px
  color: Colors.white, // This corresponds to color: #FFFFFF in CSS
);

const chooseTextStyle = TextStyle(
  fontFamily: 'Roboto',
  fontStyle: FontStyle.normal,
  fontWeight: FontWeight.w700,
  fontSize: 18,
  height:
      1.17, // This corresponds to line-height: 21px with a font-size of 18px
  color: secondaryTextColor, // This corresponds to color: #211772 in CSS
);

const primaryStyle = TextStyle(
  fontFamily: 'Roboto',
  fontStyle: FontStyle.normal,
  fontWeight: FontWeight.w400,
  fontSize: 16,
  height: 1.06,
  color: Color(0xFF211772),
);
