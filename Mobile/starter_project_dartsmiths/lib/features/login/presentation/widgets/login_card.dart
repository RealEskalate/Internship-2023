import 'package:dartsmiths/features/login/presentation/widgets/custom_login_text.dart';
import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';
import '../../../../core/utils/ui_converter.dart';

class LoginCard extends StatefulWidget {
  const LoginCard({super.key});

  @override
  State<LoginCard> createState() => _LoginCardState();
}

class _LoginCardState extends State<LoginCard> {
  bool isObsecured = true;

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        decoration: const BoxDecoration(
            borderRadius: BorderRadius.only(
              topLeft: Radius.circular(16),
              topRight: Radius.circular(16),
            ),
            color: whiteColor),
        child: Padding(
          padding: EdgeInsets.fromLTRB(
            UIConverter.getComponentWidth(context, 40),
            UIConverter.getComponentHeight(context, 32),
            UIConverter.getComponentWidth(context, 40),
            UIConverter.getComponentHeight(context, 0),
          ),
          child: Column(
            children: [
              Column(children: [
                Row(
                  children: [
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        const Text(
                          "Welcome back",
                          style: TextStyle(
                            fontWeight: FontWeight.w600,
                            fontSize: 16,
                            fontFamily: 'Urbanist',
                          ),
                        ),
                        SizedBox(
                          height: UIConverter.getComponentHeight(context, 10),
                        ),
                        const Text(
                          "Sign in with your account",
                          style: TextStyle(
                            fontSize: 10,
                            color: secondaryTextColor,
                            fontWeight: FontWeight.w800,
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
                SizedBox(
                  // height: UIConverter.getComponentHeight(context, 40),
                  height: MediaQuery.of(context).size.height * 0.0166666666,
                ),
                TextFormField(
                  decoration: const InputDecoration(
                      label: Text(
                        "Username",
                        style: TextStyle(
                            fontStyle: FontStyle.italic, fontSize: 14),
                      ),
                      hintText: "Jonathandavis@gmail.com",
                      hintStyle: TextStyle(fontSize: 12)),
                ),
                TextFormField(
                  obscureText: isObsecured,
                  decoration: InputDecoration(
                      label: const Text(
                        "Password",
                        style: TextStyle(
                            fontStyle: FontStyle.italic, fontSize: 14),
                      ),
                      suffix: InkWell(
                        onTap: () {
                          setState(() {
                            isObsecured = !isObsecured;
                          });
                        },
                        child: const Text(
                          "Show",
                          style: TextStyle(color: primaryColor, fontSize: 10),
                        ),
                      ),
                      hintStyle: const TextStyle(fontSize: 12)),
                ),
                SizedBox(
                  height: UIConverter.getComponentHeight(context, 150),
                ),
                SizedBox(
                  height: UIConverter.getComponentHeight(context, 60),
                  width: UIConverter.getComponentWidth(context, 295),
                  child: ElevatedButton(
                      style: ElevatedButton.styleFrom(
                        backgroundColor: primaryColor,
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(8),
                        ),
                      ),
                      onPressed: () => {},
                      child: const CustomLoginText(str: "LOGIN")),
                ),
                SizedBox(
                  height: UIConverter.getComponentHeight(context, 15),
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const Text(
                      "Forgot your password?",
                      style: TextStyle(
                        fontSize: 10,
                        color: secondaryTextColor,
                        fontWeight: FontWeight.w800,
                      ),
                    ),
                    SizedBox(
                      width: UIConverter.getComponentHeight(context, 10),
                    ),
                    InkWell(
                      onTap: () {},
                      child: const Text(
                        "Reset here",
                        style: TextStyle(color: primaryColor, fontSize: 10),
                      ),
                    ),
                  ],
                )
              ]),
            ],
          ),
        ),
      ),
    );
  }
}
