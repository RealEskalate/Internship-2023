import 'package:flutter/material.dart';

class AnimatedEntry extends StatefulWidget {
  late double width;
  late double height;
  late AssetImage image;
  late double? top;
  late double? left;
  late double? right;
  late double? bottom;
  AnimatedEntry(
      {super.key,
      required this.width,
      required this.height,
      required this.image,
      this.top,
      this.left,
      this.right,
      this.bottom});

  @override
  State<AnimatedEntry> createState() => _AnimatedEntryState();
}

class _AnimatedEntryState extends State<AnimatedEntry> {
  static const Duration duration = Duration(seconds: 2);
  static const Color shadowColor = Color.fromARGB(166, 11, 59, 104);
  @override
  Widget build(BuildContext context) {
    return AnimatedPositioned(
      top: widget.top,
      left: widget.left,
      right: widget.right,
      bottom: widget.bottom,
      duration: duration,
      curve: Curves.decelerate,
      child: Container(
        margin: const EdgeInsets.all(5),
        width: widget.width,
        height: widget.height,
        decoration: BoxDecoration(
          boxShadow: const [
            BoxShadow(
              color: shadowColor,
              spreadRadius: 1,
              blurRadius: 30,
              offset: Offset(-5, 5),
            )
          ],
          borderRadius: const BorderRadius.all(Radius.circular(25)),
          image: DecorationImage(
            fit: BoxFit.fitWidth,
            image: widget.image,
          ),
        ),
      ),
    );
  }
}
