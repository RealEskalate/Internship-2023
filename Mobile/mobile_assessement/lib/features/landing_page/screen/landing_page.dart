import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:mobile_assessement/core/utils/colors.dart';
import 'package:mobile_assessement/features/landing_page/widgets/background_color_image.dart';
import 'package:mobile_assessement/features/landing_page/widgets/cloud_image.dart';
import 'package:mobile_assessement/features/landing_page/widgets/custom_button.dart';
import 'package:mobile_assessement/features/landing_page/widgets/description_text.dart';
import 'package:mobile_assessement/features/landing_page/widgets/forecast_text.dart';
import 'package:mobile_assessement/features/landing_page/widgets/weather_text.dart';
import 'package:mobile_assessement/features/weatherify/presentation/screen/home_page.dart';

class LandingPage extends StatelessWidget {
  const LandingPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          const BackGroundColorImage(),
          Padding(
            padding: EdgeInsets.all(MediaQuery.of(context).size.width * 0.07),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const CloudImage(),
                const WeatherText(),
                SizedBox(
                  height: MediaQuery.of(context).size.height * 0.001,
                ),
                const ForeCastText(),
                SizedBox(
                  height: MediaQuery.of(context).size.height * 0.02,
                ),
                const DescriptionText(),
                SizedBox(
                  height: MediaQuery.of(context).size.height * 0.0001,
                ),
                CustomButton(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => const HomePage(),
                      ),
                    );
                  },
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
