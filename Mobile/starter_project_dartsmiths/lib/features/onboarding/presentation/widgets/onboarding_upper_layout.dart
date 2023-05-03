import 'package:flutter/material.dart';
class OnboardingUpperImage extends StatelessWidget {
  const OnboardingUpperImage({super.key});
  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Padding(
          padding: const EdgeInsets.only(right: 10.0),
          child: Container(
            height: MediaQuery.of(context).size.height / 4,
            width: MediaQuery.of(context).size.width / 4,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(24.0),
              image: const DecorationImage(
                image: AssetImage('assets/images/onboarding1.jpg'),
                fit: BoxFit.cover,
              ),
            ),
          ),
        ),
        Expanded(
          child: Container(
            height: MediaQuery.of(context).size.height / 4,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(24.0),
              image: const DecorationImage(
                image: AssetImage('assets/images/onboarding2.jpg'),
                fit: BoxFit.cover,
              ),
            ),
          ),
        )
      ],
    );
  }
}
