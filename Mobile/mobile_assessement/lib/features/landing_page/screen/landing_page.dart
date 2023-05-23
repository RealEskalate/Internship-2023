import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

class LandingPage extends StatelessWidget {
  const LandingPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        const Image(image: AssetImage("assets/images/landing_page_bg.png")),
        Column(
          children: const [
            Image(image: AssetImage("assets/images/cloud_image.png")),
            Text("Weather", style: TextStyle(fontSize: 20, color: Colors.white),),
            Text("Forecast App"),
            Text(
                "It's the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has."),
          ],
        ),
      ],
    );
  }
}
