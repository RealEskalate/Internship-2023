import 'package:flutter/material.dart';
import 'package:matador/features/example/presentation/widgets/background_container.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({super.key});

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Container(
      color: const Color.fromARGB(255, 233, 233, 233),
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
