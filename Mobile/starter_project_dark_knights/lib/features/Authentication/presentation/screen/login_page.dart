import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import '../widgets/log_in_form.dart';
import '../widgets/navigation_bar.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: whiteColor,
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          Align(
            alignment: Alignment.topCenter,
            child: Image.asset(
              'images/a2sv.png',
              height: MediaQuery.of(context).size.height * 0.2,
              fit: BoxFit.fitWidth,
            ),
          ),
          Expanded(
            child: Stack(children: [
              Container(
                width: double.infinity,
                decoration: const BoxDecoration(
                    color: primaryColor,
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(25.0),
                      topRight: Radius.circular(25.0),
                    )),
                height: MediaQuery.of(context).size.height * 0.18,
                padding: EdgeInsets.symmetric(
                  horizontal: MediaQuery.of(context).size.width * 0.16,
                  vertical: MediaQuery.of(context).size.height * 0.03,
                ),
                child: LoginSignUpNavigation(),
              ),
              Positioned(
                  top: MediaQuery.of(context).size.height * 0.09,
                  child: Container(
                    width: MediaQuery.of(context).size.width,
                    height: MediaQuery.of(context).size.height,
                    decoration: const BoxDecoration(
                        border: null,
                        color: whiteColor,
                        borderRadius: const BorderRadius.only(
                          topLeft: Radius.circular(25.0),
                          topRight: Radius.circular(25.0),
                        )),
                    padding: EdgeInsets.symmetric(
                        horizontal: MediaQuery.of(context).size.width * 0.09,
                        vertical: MediaQuery.of(context).size.height * 0.04),
                    child: LogInForm(),
                  ))
            ]),
          ),
        ],
      ),
    );
  }
}
