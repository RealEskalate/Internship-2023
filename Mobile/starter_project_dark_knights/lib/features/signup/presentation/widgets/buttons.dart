import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class button_widget extends StatelessWidget {
  const button_widget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      style: ElevatedButton.styleFrom(
          backgroundColor: primaryColor,
          shape:
              RoundedRectangleBorder(borderRadius: BorderRadius.circular(10))),
      onPressed: () {},
      child: const Text(
        'SIGN UP',
        style: TextStyle(
            fontFamily: "Urbanist", fontWeight: FontWeight.w700, fontSize: 16),
      ),
    );
  }
}
