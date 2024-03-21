import 'package:flutter/material.dart';

//This widget accepts the imageUrl and boolean value isLarge to give us large and small containers
class OnboardingStepperBox extends StatelessWidget {
  OnboardingStepperBox({required this.imageUrl, required this.isLarge, Key? key})
      : super(key: key);

  final String imageUrl;
  final bool isLarge;

  @override
  Widget build(BuildContext context) {
    final double height = MediaQuery.of(context).size.height * 0.23;
    final double width = isLarge
        ? MediaQuery.of(context).size.width * 0.51
        : MediaQuery.of(context).size.width * 0.2;

    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Container(
        height: height,
        width: width,
        decoration: BoxDecoration(
          boxShadow: const [
            BoxShadow(
              color: Colors.grey,
              blurRadius: 10,
              offset: Offset(0, 15),
            )
          ],
          borderRadius: BorderRadius.circular(24),
          image: DecorationImage(
            image: AssetImage(imageUrl),
            fit: BoxFit.cover,
          ),
        ),
      ),
    );
  }
}
