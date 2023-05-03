import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import '../widgets/article_content.dart';
import '../widgets/onboarding_lower_layout.dart';
import '../widgets/onboarding_upper_layout.dart';

class OnboardingPage extends StatelessWidget {
  const OnboardingPage({
    super.key,
  });
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Container(
            color: scaffoldBackground,
            child: Column(
              children: [
                Padding(
                  padding: const EdgeInsets.all(39.79),
                  child: Column(
                    children: const [
                      OnboardingUpperImage(),
                      OnboardingLowerImage(),
                    ],
                  ),
                ),
              ],
            ),
          ),
          const Positioned(
            bottom: 0,
            child: ArticleContent(),
          ),
        ],
      ),
    );
  }
}
