import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class ButtonWidget extends StatelessWidget {
  const ButtonWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final double screenHeight = MediaQuery.of(context).size.height;
    return ElevatedButton(
      style: ElevatedButton.styleFrom(
          backgroundColor: primaryColor,
          shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(screenHeight * 0.02))),
      onPressed: () {},
      child: Text(
        'SIGN UP',
        style: TextStyle(
            fontFamily: "Urbanist",
            fontWeight: FontWeight.w700,
            fontSize: screenHeight * 0.02),
      ),
    );
  }
}
