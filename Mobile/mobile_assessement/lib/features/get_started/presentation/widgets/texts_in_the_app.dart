import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:mobile_assessement/core/utils/constants/styles.dart';

class TextsInTheApp extends StatelessWidget {
  TextsInTheApp({super.key});

  @override
  Widget build(BuildContext context) {
    var description =
        "It\'s the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has.";
    return Column(
      mainAxisAlignment: MainAxisAlignment.start,
      children: [
        Text(
          'Weather',
          style: weatherTextStyle,
        ),
        Text(
          'Forecast App.',
          style: ForecastTextStyle,
        ),
        Text(
          description,
          style: descriptionTextStyle,
        )
      ],
    );
  }
}
