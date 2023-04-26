import 'package:flutter/material.dart';
import 'package:matador/features/splash/presentation/widgets/background_container.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({super.key});

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  static const Color backgroundColor = Color.fromARGB(125, 244, 247, 255);
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Container(
      color: backgroundColor,
      child: Stack(
        children: [
          BackgroundContainer(top: 200, left: 300),
          BackgroundContainer(bottom: 200, right: 500),
          BackgroundContainer(
            bottom: 500,
            left: 500,
          ),
          Center(
            child: Image(
              width: size.width / 2,
              image: const AssetImage("assets/images/a2sv_logo.png"),
            ),
          ),
        ],
      ),
    );
  }
}
