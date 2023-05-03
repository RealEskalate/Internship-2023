import 'package:flutter/material.dart';

import '../../../../core/utils/constants/global_variables.dart';

class SignInWithYourAccount extends StatelessWidget {
  final double width;

  const SignInWithYourAccount({Key? key, required this.width})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: width,
      child: const Text(
        'Sign in with your account',
        style: TextStyle(
            color: secondaryColor,
            fontWeight: FontWeight.bold,
            fontFamily: 'Poppins',
            fontSize: 15),
      ),
    );
  }
}
