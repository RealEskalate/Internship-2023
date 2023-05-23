import 'package:flutter/material.dart';
import 'package:mobile_assessement/core/utils/colors.dart';

class WeatherText extends StatelessWidget {
  const WeatherText({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Text(
      "Weather",
      style: TextStyle(
        fontSize: MediaQuery.of(context).size.height * 0.07,
        color: primaryColor,
      ),
    );
  }
}