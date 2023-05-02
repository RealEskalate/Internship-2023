import 'package:dark_knights/features/Authentication/presentation/screen/login_page.dart';
import 'package:flutter/material.dart';

import 'colors.dart';

class TextStyles {
  static const welcomeBack = TextStyle(
    fontFamily: "Urbanist",
    color: blackColor,
    fontWeight: FontWeight.w600,
    fontSize: 24,
  );

  static const signIn = TextStyle(
    color: secondaryTextColor,
    fontWeight: FontWeight.w900,
    fontSize: 14,
  );

 static const formFieldTextStyle = TextStyle(
    fontFamily: "Urbanist",
    fontStyle: FontStyle.italic,
    color: secondaryTextColor,
    fontSize: 14,
  );

  static const hintText = TextStyle(
    color: blackColor,
    fontFamily: "Urbanist",
    fontSize: 16,
    fontWeight: FontWeight.w500,
  );
  
  static const passwordTextFieldHint = TextStyle(
    color: blackColor,
    fontSize: 24,
    letterSpacing: 8,
    fontWeight: FontWeight.w500,
  );

  static const showButton = TextStyle(
    color: secondaryColor,
    fontWeight: FontWeight.w600,
  );
  static const login = TextStyle(
            color: whiteColor,
            fontWeight: FontWeight.w700,
            fontSize: 18,
            fontFamily: "Urbanist",
          );
  static TextStyle signUp = TextStyle(
              color: whiteColor.withOpacity(0.4),
              fontWeight: FontWeight.w700,
              fontSize: 18,
              fontFamily: "Urbanist",
            );
  static const reset = TextStyle(
              color: darkPrimaryColorGradient,
              fontWeight: FontWeight.w500,
              fontSize: 14,
              fontFamily: "Urbanist");
  static const forgotPassword = TextStyle(
              fontWeight: FontWeight.w900,
              fontSize: 14,
              color: secondaryTextColor);
}
