using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    /// <summary>
    /// Static factory class for <see cref="Envelope{T}"/>.
    /// </summary>
    public abstract class Envelope
    {
        /// <summary>
        /// Creates an envelope for the given body.
        /// </summary>
        public static Envelope<T> Create<T>(T body)
        {
            return new Envelope<T>(body);
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Provides the envelope for an object that will be sent to a bus.
    /// </summary>
    public class Envelope<TE> : Envelope
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets the body.
        /// </summary>
        public TE Body { get; private set; }

        /// <summary>
        /// Gets or sets the delay for sending, enqueing or processing the body.
        /// </summary>
        public TimeSpan Delay { get; set; }

        /// <summary>
        /// Gets or sets the time to live for the message in the queue.
        /// </summary>
        public TimeSpan TimeToLive { get; set; }

        /// <summary>
        /// Gets the correlation id.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets the correlation id.
        /// </summary>
        public string MessageId { get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TE}" /> class.
        /// </summary>
        /// <param name="body">The body.</param>
        public Envelope(TE body)
        {
            this.Body = body;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates an envelope for the given body.
        /// </summary>
        /// <typeparam name="TC"></typeparam>
        /// <param name="body">The body.</param>
        /// <returns></returns>
        public new static Envelope<TC> Create<TC>(TC body)
        {
            return new Envelope<TC>(body);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="TE"/> to <see cref="Envelope{TE}"/>.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Envelope<TE>(TE body)
        {
            return Envelope.Create(body);
        }

        #endregion
    }
}
