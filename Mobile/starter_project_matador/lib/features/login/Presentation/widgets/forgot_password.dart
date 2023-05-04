import 'package:flutter/material.dart';

import '../../../../core/utils/constants/global_variables.dart';

class ForgotPassword extends StatelessWidget {
  const ForgotPassword({super.key});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: const [
        Text(
          'Forgot Your Password?',
          style: TextStyle(
              color: secondaryColor,
              fontWeight: FontWeight.bold,
              fontFamily: 'Poppins'),
        ),
        TextButton(
            onPressed: null,
            child: Text(
              'Reset here',
              style: TextStyle(color: linkColor, fontFamily: 'Urbanist'),
            )),
      ],
    );
  }
}
