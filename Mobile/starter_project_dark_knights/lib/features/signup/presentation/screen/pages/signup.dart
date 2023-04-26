import 'package:flutter/material.dart';
import '../../../../../core/utils/colors.dart';
import '../../widgets/navigation.dart';
import '../../widgets/buttons.dart';
import '../../../../../core/utils/colors.dart';
import '../../widgets/signup_form.dart';

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
                child: Container(
                    padding: const EdgeInsets.symmetric(horizontal: 0.0),
                    child: Column(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          SizedBox(height: screenHeight * 0.05),
                          Image.asset(
                            '../../../../../../../assets/log.png',
                            height: screenHeight * 0.08,
                          ),
                          SizedBox(height: screenHeight * 0.07),
                          Stack(children: [
                            Container(
                              decoration: const BoxDecoration(
                                color: primaryColor,
                                borderRadius: BorderRadius.only(
                                  topLeft: Radius.circular(40),
                                  topRight: Radius.circular(40),
                                ),
                              ),
                              height: 90,
                              child: const TopNavigate(),
                            ),
                            Positioned(
                              right: 0,
                              left: 0,
                              top: 70,
                              bottom: 0,
                              child: Container(
                                height: 10,
                                width: 30,
                                decoration: const BoxDecoration(
                                  color: whiteColor,
                                  borderRadius: BorderRadius.only(
                                    topLeft: Radius.circular(30),
                                    topRight: Radius.circular(30),
                                  ),
                                ),
                              ),
                            ),
                            Padding(
                                padding: const EdgeInsets.only(
                                    left: 50, right: 40, top: 100),
                                child: SignUpForm()),
                          ])
                        ])))));
  }
}
