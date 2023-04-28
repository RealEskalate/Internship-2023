import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import '../widgets/navigation.dart';
import '../widgets/signup_form.dart';

class SignUpPage extends StatelessWidget {
  const SignUpPage({
    super.key,
  });
  @override
  Widget build(BuildContext context) {
    final double screenHeight = MediaQuery.of(context).size.height;

    return Scaffold(
        backgroundColor: whiteColor,
        body: SafeArea(
            child: SingleChildScrollView(
                child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
              SizedBox(height: screenHeight * 0.05),
              Image.asset(
                'assets/images/logo.png',
                height: screenHeight * 0.08,
              ),
              SizedBox(height: screenHeight * 0.07),
              Stack(children: [
                Container(
                  decoration: BoxDecoration(
                    color: primaryColor,
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(screenHeight * 0.04),
                      topRight: Radius.circular(screenHeight * 0.04),
                    ),
                  ),
                  height: screenHeight * 0.12,
                  child: const TopNavigateBar(),
                ),
                Positioned(
                  right: screenHeight * 0,
                  left: screenHeight * 0,
                  top: screenHeight * 0.08,
                  // bottom: 0,
                  child: Container(
                    height: screenHeight * 0.15,
                    decoration: BoxDecoration(
                      color: whiteColor,
                      borderRadius: BorderRadius.only(
                        topLeft: Radius.circular(screenHeight * 0.04),
                        topRight: Radius.circular(screenHeight * 0.04),
                      ),
                    ),
                  ),
                ),
                Padding(
                    padding: EdgeInsets.only(
                        left: screenHeight * 0.04,
                        right: screenHeight * 0.04,
                        top: screenHeight * 0.12),
                    child: const SignUpForm()),
              ])
            ]))));
  }
}
