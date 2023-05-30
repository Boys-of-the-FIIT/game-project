using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = System.Object;

public class StateMachine
{
   private IState _currentState;
   
   private Dictionary<Type, List<Transition>> transitions = new();
   private List<Transition> currentTransitions = new();
   private List<Transition> anyTransitions = new();
   
   private static List<Transition> EmptyTransitions = new(0);

   public void Tick()
   {
      var transition = GetTransition();
      if (transition != null)
         SetState(transition.To);
      
      _currentState?.Tick();
   }

   public void SetState(IState state)
   {
      if (state == _currentState)
         return;
      
      _currentState?.OnExit();
      _currentState = state;
      
      transitions.TryGetValue(_currentState.GetType(), out currentTransitions);
      if (currentTransitions == null)
         currentTransitions = EmptyTransitions;
      
      _currentState.OnEnter();
   }

   public void AddTransition(IState from, IState to, Func<bool> predicate)
   {
      if (this.transitions.TryGetValue(from.GetType(), out var transitions) == false)
      {
         transitions = new List<Transition>();
         this.transitions[from.GetType()] = transitions;
      }
      
      transitions.Add(new Transition(to, predicate));
   }

   public void AddAnyTransition(IState state, Func<bool> predicate)
   {
      anyTransitions.Add(new Transition(state, predicate));
   }

   private class Transition
   {
      public Func<bool> Condition {get; }
      public IState To { get; }

      public Transition(IState to, Func<bool> condition)
      {
         To = to;
         Condition = condition;
      }
   }

   private Transition GetTransition()
   {
      foreach(var transition in anyTransitions)
         if (transition.Condition())
            return transition;
      
      foreach (var transition in currentTransitions)
         if (transition.Condition())
            return transition;

      return null;
   }
}