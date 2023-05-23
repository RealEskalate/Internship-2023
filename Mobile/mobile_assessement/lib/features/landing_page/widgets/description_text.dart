import 'package:flutter/material.dart';

class DescriptionText extends StatelessWidget {
  const DescriptionText({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Text(
      "It's the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has.",
      style: TextStyle(
          color: Colors.white,
          height: MediaQuery.of(context).size.height * 0.002),
    );
  }
}