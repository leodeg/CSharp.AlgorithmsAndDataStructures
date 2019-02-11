﻿using System;

namespace DataStructures
{
	public class BinaryNode
	{
		public BinaryNode Left { get; set; }
		public BinaryNode Right { get; set; }
		public int Value { get; set; }

		public BinaryNode (int value)
		{
			Left = null;
			Right = null;
			Value = value;
		}

		public BinaryNode (BinaryNode left, BinaryNode right)
		{
			Left = left;
			Right = right;
			Value = default (int);
		}

		public BinaryNode (BinaryNode left, BinaryNode right, int value)
		{
			Left = left;
			Right = right;
			Value = value;
		}
	}

	public class BinaryTree
	{
		/// <summary>
		/// The most base node of tree.
		/// </summary>
		private BinaryNode Root { get; set; }

		/// <summary>
		/// Create empty tree with one empty node.
		/// </summary>
		public BinaryTree ()
		{
			Root = null;
			Count = 0;
		}

		/// <summary>
		/// Create tree with one node that hold the value.
		/// </summary>
		public BinaryTree (int value)
		{
			Root = new BinaryNode (value);
			Count++;
		}

		/// <summary>
		/// Length of the binary tree.
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Return first node.
		/// </summary>
		public BinaryNode First => Root;

		/// <summary>
		/// Return value of the first node.
		/// </summary>
		public int FirstValue => Root.Value;

		/// <summary>
		/// Find node by value.
		/// </summary>
		/// <param name="value">value that need to find</param>
		public BinaryNode FindNode (int value)
		{
			BinaryNode root = Root;
			while (root != null)
			{
				int current = root.Value;
				if (current.Equals (value)) break;
				if (current < value) root = root.Right;
				else root = root.Left;
			}
			return root;
		}

		/// <summary>
		/// Find node by value. Required a root (first) node of the current tree.
		/// </summary>
		/// <param name="root">first node of the current tree</param>
		/// <param name="value">value that need to find</param>
		public BinaryNode FindNode (BinaryNode root, int value)
		{
			if (root == null) return null;

			int current = root.Value;
			if (current.Equals (value)) return root;
			if (current < value) return FindNode (root.Right, value);
			else return FindNode (root.Left, value);
		}

		/// <summary>
		/// Calculate height of tree.
		/// <para>Time Complexity - BigO(n) where n is amount of nodes</para>
		/// </summary>
		/// <param name="node">first node of tree</param>
		public static int TreeHeight (BinaryNode node)
		{
			if (node == null) return 0;
			return 1 + Math.Max (TreeHeight (node.Left), TreeHeight (node.Right));
		}
	}
}