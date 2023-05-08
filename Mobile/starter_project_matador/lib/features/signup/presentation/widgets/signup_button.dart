import "package:flutter/material.dart";
import '../../../../core/utils/constants/colors.dart';
import '../../../../core/utils/constants/styles.dart';

class CustomButton extends StatelessWidget {
  const CustomButton({super.key});

  @override
  Widget build(BuildContext context) {
    var Height = MediaQuery.of(context).size.height;
    var Width = MediaQuery.of(context).size.width;
    return Container(
      width: Width * 0.8,
      height: (56 / 812) * Height,
      decoration: BoxDecoration(
        color: primaryColor,
        borderRadius: BorderRadius.circular((20 / 812) * Height),
      ),
      child: Center(
        child: Text(
          'SIGNUP',
          style: signupInButtonTextStyle,
        ),
      ),
    );
  }
}
