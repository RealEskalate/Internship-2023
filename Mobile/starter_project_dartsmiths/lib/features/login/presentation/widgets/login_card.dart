import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class LoginCard extends StatelessWidget {
  const LoginCard({super.key});

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        decoration: const BoxDecoration(
            borderRadius: BorderRadius.only(
              topLeft: Radius.circular(25),
              topRight: Radius.circular(25),
            ),
            color: whiteColor),
        child: Padding(
          padding: const EdgeInsets.fromLTRB(30, 15, 30, 0),
          child: Column(
            children: [
              Column(children: [
                Row(
                  children: [
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: const [
                        Text(
                          "Welcome back",
                          style: TextStyle(
                              fontWeight: FontWeight.w500, fontSize: 20),
                        ),
                        SizedBox(
                          height: 10,
                        ),
                        Text(
                          "Sign in with your account",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                      ],
                    ),
                  ],
                ),
                const SizedBox(
                  height: 25,
                ),
                TextFormField(
                  decoration: const InputDecoration(
                      label: Text(
                        "Username",
                      ),
                      hintText: "Jonathandavis@gmail.com"),
                ),
                TextFormField(
                  obscureText: true,
                  decoration: InputDecoration(
                      label: const Text(
                        "Password",
                      ),
                      suffixIcon: TextButton(
                        onPressed: () {},
                        child: const Text(
                          "Show",
                          style: TextStyle(color: primaryColor),
                        ),
                      )
                      // suffixIcon: Text(
                      //   "show",
                      //   style: TextStyle(
                      //     color: primaryColor,
                      //   ),
                      // ),
                      ),
                ),
                const SizedBox(
                  height: 50,
                ),
                SizedBox(
                  height: 60,
                  width: 295,
                  child: ElevatedButton(
                    onPressed: () => {},
                    child: const Text("LOGIN"),
                  ),
                ),
                const SizedBox(
                  height: 10,
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: const [
                    Text(
                      "Forgot your password?",
                      style: TextStyle(fontWeight: FontWeight.bold),
                    ),
                    SizedBox(
                      width: 5,
                    ),
                    Text(
                      "Reset here",
                      style: TextStyle(color: primaryColor),
                    )
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
