import 'package:flutter/material.dart';

class ForeCastText extends StatelessWidget {
  const ForeCastText({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Text("Forecast App.",
        style: TextStyle(
          fontSize: MediaQuery.of(context).size.height * 0.05,
          color: Colors.white,
        ));
  }
}