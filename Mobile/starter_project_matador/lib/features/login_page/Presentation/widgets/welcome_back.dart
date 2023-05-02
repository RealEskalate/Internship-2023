import 'package:flutter/material.dart';

import '../../../../core/utils/constants/global_variables.dart';

class WelcomeBack extends StatelessWidget {
  final double width;
  const WelcomeBack({Key? key, required this.width}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: width,
      child: const Text(
        'Welcome back',
        style: TextStyle(
            color: headingColor,
            fontSize: 30,
            fontFamily: 'Urbanist',
            fontWeight: FontWeight.bold),
      ),
    );
  }
}
