import 'package:flutter/material.dart';

class WeatherifyLogo extends StatelessWidget {
  const WeatherifyLogo({super.key});

  @override
  Widget build(BuildContext context) {
    double Height = MediaQuery.of(context).size.height;
    double Width = MediaQuery.of(context).size.width;
    return Image.asset(
      "assets/logo.jpg",
      height: (220 / 375) * Width,
      width: (220 / 375) * Width,
    );
  }
}
