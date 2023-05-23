import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:mobile_assessement/features/get_started/presentation/widgets/get_started_button.dart';
import 'package:mobile_assessement/features/get_started/presentation/widgets/logo.dart';
import 'package:mobile_assessement/features/get_started/presentation/widgets/texts_in_the_app.dart';

class getStartedPage extends StatelessWidget {
  const getStartedPage({super.key});
  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Container(
          padding: EdgeInsets.only(top: 14),
          child: WeatherifyLogo(),
        ),
        Container(
          padding: EdgeInsets.only(top: 20),
          child: TextsInTheApp(),
        ),
        CustomButton(),
      ],
    );
  }
}
