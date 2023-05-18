import 'package:flutter/material.dart';

class A2SVLogo extends StatelessWidget {
  final double width;
  final double height;
  const A2SVLogo({Key? key, required this.width, required this.height})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: width * 0.376,
      height: height * 0.21,
      child: Image.asset(
        '../../../assets/images/A2SVBlue.png',
        fit: BoxFit.contain,
      ),
    );
  }
}
